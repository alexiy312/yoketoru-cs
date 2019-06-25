using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yoketoru_cs
{
    //Form1の中に作るとForm1の中でのみ呼び出しできる
    //SCENEの定義
    enum SCENE
    {
        TITLE,
        GAME,
        CLEAR,
        GAMEOVER,
        NONE
    }
    public partial class Form1 : Form
    {
        //SCENE変数の定義
        SCENE nowscene;
        SCENE nextscene;

        const int ITEM_COUNT = 10;
        const int ENEMY_COUNT = 10;
        const int TOTAL_COUNT = ITEM_COUNT + ENEMY_COUNT;

        //labelsの記憶領域確保
        Label[] labels = new Label[TOTAL_COUNT];

        int[] vx = new int[TOTAL_COUNT];
        int[] vy = new int[TOTAL_COUNT];

        Random rand = new Random();

        int left;
        int time;
        
        public Form1()
        {
            InitializeComponent();

            //SCENEを代入
            nowscene = SCENE.NONE;
            nextscene = SCENE.TITLE;

            for (int i = 0; i < TOTAL_COUNT; i++)
            {
                //個々のlabelsの記憶領域確保
                labels[i] = new Label();

                //labels生成
                Controls.Add(labels[i]);
                labels[i].AutoSize = true;
                labels[i].Visible = false;

                if (i < ITEM_COUNT)
                {
                    labels[i].Text = "★";
                    labels[i].ForeColor = Color.Tomato;
                }
                else
                {
                    labels[i].Text = "★";
                    labels[i].ForeColor = Color.Black;
                }
            }
        }

        void initScene()
        {
            if (nextscene == SCENE.NONE)
                return;

            nowscene = nextscene;
            nextscene = SCENE.NONE;

            switch (nowscene)
            {
                case SCENE.TITLE:
                    startButton.Visible = true;
                    titleLabel.Visible = true;
                    button1.Visible = false;
                    label1.Visible = false;
                    label2.Visible = false;
                    break;
                case SCENE.GAME:
                    startButton.Visible = false;
                    titleLabel.Visible = false;
                    left = ITEM_COUNT;
                    time = 30 * ITEM_COUNT;
                    leftLabel.Text = "残り:" + left + "個";
                    for (int i = 0; i < TOTAL_COUNT; i++)
                    {
                        vx[i] = rand.Next(-5, 6);
                        vy[i] = rand.Next(-5, 6);

                        labels[i].Left = rand.Next(0, ClientSize.Width - labels[i].Width);
                        labels[i].Top = rand.Next(0, ClientSize.Height - labels[i].Height);
                        labels[i].Visible = true;
                    }
                    break;
                case SCENE.CLEAR:
                    button1.Visible = true;
                    label1.Visible = true;
                    for (int i = 0; i < TOTAL_COUNT; i++)
                    {
                        labels[i].Visible = false;
                    }
                    break;
                case SCENE.GAMEOVER:
                    button1.Visible = true;
                    label2.Visible = true;
                    for (int i = 0; i < TOTAL_COUNT; i++)
                    {
                            labels[i].Visible = false;
                    }
                    break;
            }
        }

        void updateScene()
        {
            if (nowscene != SCENE.GAME)
                return;
            else
            {
                for (int i = 0; i < TOTAL_COUNT; i++)
                {
                    Point mp = PointToClient(MousePosition);

                    labels[i].Left += vx[i];
                    labels[i].Top += vy[i];

                    if (labels[i].Left < 0)
                        vx[i] = Math.Abs(vx[i]);
                    if (labels[i].Left > ClientSize.Width - labels[i].Width)
                        vx[i] = -Math.Abs(vx[i]);
                    if (labels[i].Top < 0)
                        vy[i] = Math.Abs(vy[i]);
                    if (labels[i].Top > ClientSize.Height - labels[i].Height)
                        vy[i] = -Math.Abs(vy[i]);

                    if (i < ITEM_COUNT)
                    {
                        if ((labels[i].Left < mp.X) &&
                            (labels[i].Right > mp.X) &&
                            (labels[i].Top < mp.Y) &&
                            (labels[i].Bottom > mp.Y) &&
                            (labels[i].Visible == true))
                        {
                            labels[i].Visible = false;
                            left--;
                            leftLabel.Text = "残り:" + left + "個";

                            if (left <= 0)
                                nextscene = SCENE.CLEAR;
                        }
                    }
                    else
                    {
                        if ((labels[i].Left < mp.X) &&
                            (labels[i].Right > mp.X) &&
                            (labels[i].Top < mp.Y) &&
                            (labels[i].Bottom > mp.Y) &&
                            (labels[i].Visible == true))
                        {
                            nextscene = SCENE.GAMEOVER;
                        }
                    }
                }

                time--;
                timeLabel.Text = "Time:" + time;
                if (time <= 0)
                {
                    nextscene = SCENE.GAMEOVER;
                }
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            nextscene = SCENE.GAME;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //メソッド呼び出し
            initScene();
            updateScene();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            nextscene = SCENE.TITLE;
        }
    }
}
