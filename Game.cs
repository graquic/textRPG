using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG;

namespace textRPG
{
    public class Game
    {
        private bool isRunning = true;

        Scene currentScene;

        MainMenuScene mainMenuScene;
        MapScene mapScene;
        BattleScene battleScene;
        InventoryScene inventoryScene;
        SkillScene skillScene;

        public void Run()
        {
            // 초기화
            Init();

            // 게임 프로세스

            // 루프

            while (isRunning)
            {
                // 렌더링
                Render();

                // 입력 - 입력이 한번만 입력되지 않는 경우가 존재 
                // 갱신
                Update();
            }

            // 마무리
        }

        // 초기화 메서드
        private void Init()
        {
            Console.CursorVisible = false;
            Data.Instance.Init();

            mainMenuScene = new MainMenuScene(this);
            mapScene = new MapScene(this);
            battleScene = new BattleScene(this);
            inventoryScene = new InventoryScene(this);
            skillScene = new SkillScene(this);

            currentScene = mainMenuScene;

        }

        // 렌더링 메서드
        private void Render()
        {
            Console.Clear();
            currentScene.Render();
        }

        // 입력 메서드
        private void Input()
        {

        }

        // 갱신 메서드
        private void Update()
        {
            Input();
            currentScene.Update();
        }

        // 마무리 메서드
        private void Release()
        {

        }

        public void BattleStart(Monster monster)
        {
            currentScene = battleScene;
            battleScene.StartBattle(monster);

        }

        public void Map()
        {
            currentScene = mapScene;

        }

        public void Inventory()
        {
            currentScene = inventoryScene;
        }

        public void Skill()
        {
            currentScene = skillScene;
        }



        public void GameStart()
        {
            mapScene.GenerateMap();
            currentScene = mapScene;
        }

        public void GameOver()
        {
            Console.WriteLine("게임을 종료합니다.");
            isRunning = false;
        }


    }

}





/******************************************************************************************
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 *****************************************************************************************/