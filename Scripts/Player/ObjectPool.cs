using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool//不挂在任何物体上，所以不需要继承Mono
{
    private static ObjectPool instance;//声明静态实例
    //使用队列存储物体来作为value，这里使用队列是因为入队和出队的操作较为方便
    private Dictionary<string, Queue<GameObject>> objectPool = new Dictionary<string, Queue<GameObject>>();
    //为了不让窗口杂乱，声明一个GameObject类型的参数作为所有生成物体的父物体
    private GameObject pool;
    public static ObjectPool Instance//声明公有的静态属性来修饰实例
    {
        get
        {
            if (instance == null)
            {
                instance = new ObjectPool();//如果没有实例就生成并赋值
            }

            return instance;
        }
    }//希望不同的物体可以被分开存储，在这种情况下使用字典是最合适的
    
    //================================================================
    //声明一个公有函数GetObject并传入一个GameObject类型的参数用来获取对应的游戏对象
    public GameObject GetObject(GameObject prefab)
    {
        //声明一个游戏物体用来获取池中的物体并返回给调用者
        GameObject _object;
        //首先是要使用预制体的名字查询字典中是否存在存储该预制体的池
        //如果存在再检查一下待分配物体数
        if (!objectPool.ContainsKey(prefab.name) || objectPool[prefab.name].Count == 0)
        {
            //如果不存在对应的池或者池中没有待分配的物体就实例化一个新物体并使用PushObject函数放入池中
            _object = GameObject.Instantiate(prefab);
            PushObject(_object);
            //然后判断场景中是否存在对象池父物体，如果没有就创建一个
            if (pool == null)
                pool = new GameObject("ObjectPool");
            //接着查找子对象池的父物体
            GameObject childPool = GameObject.Find(prefab.name + "Pool");
            if (!childPool)
            {
                childPool = new GameObject(prefab.name + "Pool");
                childPool.transform.SetParent(pool.transform);
            }

            _object.transform.SetParent(childPool.transform);
        }
        //最后按预制体名获取到对象池内的一个物体并激活该物体返回给调用者使用
        _object = objectPool[prefab.name].Dequeue();
        _object.SetActive(true);
        return _object;
    }
    
    //一个公有函数PushObject用来将用完的物体放入池中
    public void PushObject(GameObject prefab)
    {   
        //首先要获取已经用完的物体名
        //而实例化物体都会有（Clone）的后缀，需要先去掉
        string _name = prefab.name.Replace("(Clone)",string.Empty);
        //然后使用获取到的名称查找是否存在对应的对象池，不存在则新生成一个
        if (!objectPool.ContainsKey(_name))
        {
            objectPool.Add(_name, new Queue<GameObject>());
        }
        //然后将该物体放入池中并取消激活即可
        objectPool[_name].Enqueue(prefab);
        prefab.SetActive(false);
    }
}
