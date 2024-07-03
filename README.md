# **Coroutines**

This Coroutines framework has proven its reliability in various game projects and Editor Tools, offering a robust solution for asynchronous programming in Unity. It operates consistently in both Runtime and Editor modes, independent of GameObjects.

The primary motivation for developing this framework was to overcome the limitations of Unity's built-in coroutine implementation, which only functions in Runtime. Although Editor Coroutines are available as a separate package, a more unified solution was necessary.

Additionally, the framework is highly extensible, allowing developers to customize and extend its functionality to meet their specific needs.

## **API**

```csharp
namespace Coroutines
{
    public static class CoroutineAPI
    {
        public static Coroutine StartCoroutine(IEnumerator routine, object obj = null)
        {
            return CoroutineRunner.StartCoroutine(routine, obj);
        }

        public static void StopCoroutine(Coroutine routine)
        {
            CoroutineRunner.StopCoroutine(routine);
        }

        public static void StopCoroutine(IEnumerator routine)
        {
            CoroutineRunner.StopCoroutine(routine);
        }

        public static void StopCoroutine(IEnumerator routine, object reference)
        {
            CoroutineRunner.StopCoroutine(routine, reference);
        }

        public static void StopCoroutines(object reference)
        {
            CoroutineRunner.StopCoroutines(reference);
        }

        public static void StopAllCoroutines()
        {
            CoroutineRunner.StopAllCoroutines();
        }
    }
}
```

## **Custom Coroutine Waits**
```csharp
public class UnityYieldHandlers : YieldHandlers
{
    public override Dictionary<Type, Func<object, ICoroutineYield>> GetYieldHandlers()
    {
        return new Dictionary<Type, Func<object, ICoroutineYield>>
        {
            { typeof(WaitForFixedUpdate), _ => new YieldDefault() },
            { typeof(WaitForEndOfFrame), _ => new YieldDefault() },
            { typeof(WaitForSeconds), current => new YieldWaitForSeconds(float.Parse(GetInstanceField(typeof(WaitForSeconds), current, "m_Seconds").ToString())) },
            { typeof(AsyncOperation), current => new YieldAsync((AsyncOperation)current) }
        };
    }
}
```

```csharp
public class YieldWaitForSeconds : ICoroutineYield
{
    private float _timeToFinish;

    public YieldWaitForSeconds(float seconds)
    {
        _timeToFinish = Time.time + seconds;
    }

    public bool IsDone()
    {
        return _timeToFinish <= Time.time;
    }
}
```

## Integration

* Unity
* com.unity.addressables
