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

        //定数の定義
        const int ITEM_COUNT = 30;
        const int ENEMY_COUNT = 30;
        const int TOTAL_COUNT = ITEM_COUNT + ENEMY_COUNT;

        //labelsの記憶領域確保
        Label[] labels = new Label[TOTAL_COUNT];

        int[] vx = new int[TOTAL_COUNT];
        int[] vy = new int[TOTAL_COUNT];

        //乱数の準備
        Random rand = new Random();

        //残りの取っていいlabelsの数
        int left;
        //残り時間
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

                //★全体の設定
                labels[i].AutoSize = true;
                labels[i].Visible = false;

                //取っていいlabelsの設定
                if (i < ITEM_COUNT)
                {
                    labels[i].Text = "★";
                    labels[i].ForeColor = Color.Tomato;
                }
                //取ってはいけないlabelsの設定
                else
                {
                    labels[i].Text = "★";
                    labels[i].ForeColor = Color.Black;
                }
            }
        }

        //シーン毎の設定用の変数
        void initScene()
        {
            //nextsceneがNONEだったら何もしない
            if (nextscene == SCENE.NONE)
                return;

            //代入
            nowscene = nextscene;
            nextscene = SCENE.NONE;

            //nowsceneにSCENE.○○が入ってるときの処理
            switch (nowscene)
            {
                //タイトル
                case SCENE.TITLE:
                    //スタートボタンとタイトルラベルの表示、それ以外のラベル・ボタンの非表示
                    startButton.Visible = true;
                    titleLabel.Visible = true;
                    button1.Visible = false;
                    label1.Visible = false;
                    label2.Visible = false;
                    break;
                //ゲーム中
                case SCENE.GAME:
                    //不必要な物の非表示
                    startButton.Visible = false;
                    titleLabel.Visible = false;

                    //ゲーム開始時の設定
                    left = ITEM_COUNT;
                    time = 30 * ITEM_COUNT;
                    leftLabel.Text = "残り:" + left + "個";

                    for (int i = 0; i < TOTAL_COUNT; i++)
                    {
                        //labelsに割り当てる速度の乱数生成
                        vx[i] = rand.Next(-5, 6);
                        vy[i] = rand.Next(-5, 6);

                        //labelsの湧き位置の乱数生成
                        labels[i].Left = rand.Next(0, ClientSize.Width - labels[i].Width);
                        labels[i].Top = rand.Next(0, ClientSize.Height - labels[i].Height);

                        //labelsの表示
                        labels[i].Visible = true;
                    }
                    break;
                //クリア
                case SCENE.CLEAR:
                    //タイトルに戻るボタン、クリアラベルの表示
                    button1.Visible = true;
                    label1.Visible = true;

                    //labelsの非表示
                    for (int i = 0; i < TOTAL_COUNT; i++)
                    {
                        labels[i].Visible = false;
                    }
                    break;
                //ゲームオーバー
                case SCENE.GAMEOVER:
                    //タイトルに戻るボタン、ゲームオーバーラベルの表示
                    button1.Visible = true;
                    label2.Visible = true;

                    //labelsの非表示
                    for (int i = 0; i < TOTAL_COUNT; i++)
                    {
                            labels[i].Visible = false;
                    }
                    break;
            }
        }

        //ゲーム中に更新が必要な物を設定する変数
        void updateScene()
        {
            //nowsceneがGAME以外なら何もしない
            if (nowscene != SCENE.GAME)
                return;
            //nowsceneがGAMEの時
            else
            {
                for (int i = 0; i < TOTAL_COUNT; i++)
                {
                    //ゲーム画面内を基準にマウスの座標を取得
                    Point mp = PointToClient(MousePosition);

                    //labelsの速度を設定
                    labels[i].Left += vx[i];
                    labels[i].Top += vy[i];

                    //跳ね返り処理
                    if (labels[i].Left < 0)
                        vx[i] = Math.Abs(vx[i]);
                    if (labels[i].Left > ClientSize.Width - labels[i].Width)
                        vx[i] = -Math.Abs(vx[i]);
                    if (labels[i].Top < 0)
                        vy[i] = Math.Abs(vy[i]);
                    if (labels[i].Top > ClientSize.Height - labels[i].Height)
                        vy[i] = -Math.Abs(vy[i]);

                    //取っていいlabelsだったら
                    if (i < ITEM_COUNT)
                    {
                        //マウスが重なり、labelsが表示されているとき
                        if ((labels[i].Left < mp.X) &&
                            (labels[i].Right > mp.X) &&
                            (labels[i].Top < mp.Y) &&
                            (labels[i].Bottom > mp.Y) &&
                            (labels[i].Visible == true))
                        {
                            //labelsの非表示
                            labels[i].Visible = false;
                            //残り数の表示
                            left--;
                            leftLabel.Text = "残り:" + left + "個";

                            //取っていいlabelsが無くなった時CLEAR
                            if (left <= 0)
                                nextscene = SCENE.CLEAR;
                        }
                    }
                    //取ってはいけないlabelsだったら
                    else
                    {
                        //マウスが重なり、labelsが表示されているとき
                        if ((labels[i].Left < mp.X) &&
                            (labels[i].Right > mp.X) &&
                            (labels[i].Top < mp.Y) &&
                            (labels[i].Bottom > mp.Y) &&
                            (labels[i].Visible == true))
                        {
                            //ゲームオーバー
                            nextscene = SCENE.GAMEOVER;
                        }
                    }
                }

                //残り時間の表示
                time--;
                timeLabel.Text = "Time:" + time;
                //残り時間が無くなったら
                if (time <= 0)
                {
                    //ゲームオーバー
                    nextscene = SCENE.GAMEOVER;
                }
            }
        }

        //スタートボタンのクリック時
        private void StartButton_Click(object sender, EventArgs e)
        {
            //ゲームシーンに切り替え
            nextscene = SCENE.GAME;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //メソッド呼び出し
            initScene();
            updateScene();
        }

        //タイトルに戻るボタンのクリック時
        private void Button1_Click(object sender, EventArgs e)
        {
            //タイトルシーンに切り替え
            nextscene = SCENE.TITLE;
        }
    }
}
