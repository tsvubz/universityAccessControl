namespace UniversityAccessControl.Patterns.Observer;

public interface IRoomSubject
{
    void Attach(IRoomObserver observer);
    void Detach(IRoomObserver observer);
    void NotifyObservers();
}