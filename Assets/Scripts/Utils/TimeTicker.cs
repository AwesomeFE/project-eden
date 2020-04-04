using System.Threading;

public delegate void TickCallback(int costTime, int totalTime);

public class TickTimer
{
    private int costTime;
    private Timer timer;

    private readonly int tickTime;
    private readonly int totalTime;
    private readonly TickCallback tickCallback;

    public TickTimer(TickCallback tickCallback, int tickTime, int totalTime)
    {
        this.tickTime = tickTime;
        this.totalTime = totalTime;
        this.tickCallback = tickCallback;
    }

    public void Start()
    {
        InitTimer();
        timer = new Timer(TickHandler, null, tickTime, tickTime);
        tickCallback(costTime, totalTime);
    }

    public void Stop()
    {
        if (timer != null)
        {
            timer.Dispose();
        }
    }

    private void InitTimer()
    {
        costTime = 0;
    }

    private void TickHandler(object state)
    {
        if (costTime >= totalTime)
        {
            Stop();
        }
        else
        {
            costTime += tickTime;
            tickCallback(costTime, totalTime);
        }
    }
}
