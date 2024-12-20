﻿using System;

namespace Utility.Base.SingletonPattern
{
    public class LazySingleton<T> where T : new()
    {
        private static readonly Lazy<T> InstanceHolder = new Lazy<T>(() => new T());
        public static T Instance => InstanceHolder.Value;

        protected LazySingleton()
        {
        }

        //Better than

        // private static readonly object Lock = new object();
        // private static T _instance;
        //
        // public static T Instance
        // {
        //     get
        //     {
        //         if (_instance != null) return _instance;
        //         lock (Lock)
        //         {
        //             _instance ??= new T();
        //         }
        //
        //         return _instance;
        //     }
        // }
        //
        // protected LazySingleton()
        // {
        // }
    }
}