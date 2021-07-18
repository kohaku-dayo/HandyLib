using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseSystem;
using UnityEngine.SceneManagement;
using System;

namespace BaseSystem
{
    public class SceneSystem
    {
        private static SceneSystem instance = new SceneSystem();
        Scene currentScene;

        private SceneSystem(){}

        public static SceneSystem Create()
        {
            return instance;
        }

        public enum Type
        {
            //ここに存在するSceneを全て貼り付けてください。
        }

        /// <summary>
        /// 現在のシーンを取得します。
        /// </summary>
        /// <returns>現在のシーン</returns>
        internal Scene getCurrentScene()
        {
            return currentScene = SceneManager.GetActiveScene();
        }
        /// <summary>
        /// シーンをロードします。
        /// シーンが存在しない場合はエラーメッセージを出力します。
        /// </summary>
        /// <param name="Scene">シーンenum</param>
        /// <returns>SceneSystemを返します。</returns>
        internal SceneSystem loadScene(Type Scene)
        {
            if (SceneManager.GetSceneByName(Scene.ToString()).IsValid()) loadScene(Scene);
            else "Sceneが存在しません".Debug(DebugSystem.Type.BaseSystem);
            return this;
        }
    }
}
