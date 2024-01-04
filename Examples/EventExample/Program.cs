using EventExample;

var newInstance = new MyEvent();
newInstance.FeelHungry += MyMethods.GetMyPhone;
newInstance.FeelHungry += MyMethods.OpenApp;
newInstance.FeelHungry += MyMethods.ChooseMeal;
newInstance.FeelHungry += MyMethods.ChooseMeal;
newInstance.FeelHungry += MyMethods.PayOrder;
newInstance.FeelHungry += MyMethods.Die;
newInstance.FeelHungry += () => { Console.WriteLine("喝了瓶可乐，满血复活"); };
newInstance.OnFeelHungry();
newInstance.FeelHungry -= MyMethods.Die;
Console.WriteLine("---------");
newInstance.OnFeelHungry();