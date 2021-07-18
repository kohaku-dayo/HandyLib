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
        public static SceneSystem instance = new SceneSystem();
        Scene currentScene;

        private SceneSystem(){}

        public static SceneSystem Create()
        {
            return instance;
        }

        public enum Type
        {
            NewRoomMaker,
        }

        internal Scene getCurrentScene()
        {
            return currentScene = SceneManager.GetActiveScene();
        }
        internal SceneSystem loadScene(Type Scene)
        {
            if (SceneManager.GetSceneByName(Scene.ToString()).IsValid()) loadScene(Scene);
            else "Sceneが存在しません".Debug(DebugSystem.Type.BaseSystem);
            return this;
        }
    }
}
