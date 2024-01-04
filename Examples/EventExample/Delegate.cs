namespace EventExample;

// define a custom delegate that can be pointed to any method that has no params and return void
public delegate void CustomDelegate();

public class MyEvent
{
    public event CustomDelegate FeelHungry;

    public virtual void OnFeelHungry()
    {
        FeelHungry?.Invoke();
    }
}