using System;
using System.Collections.Generic;

namespace DesignPatterns1_LogischCircuit.Observable
{
    public abstract class Observable<T> : IObservable<T>, IDisposable
    {
        private List<IObserver<T>> _observers;

        public Observable()
        {
            _observers = new List<IObserver<T>>();
        }

        private struct Unsubscriber : IDisposable
        {
            private Action _unsubscribe;
            public Unsubscriber(Action unsubscribe) { _unsubscribe = unsubscribe; }
            public void Dispose() { _unsubscribe(); }
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            _observers.Add(observer);
            return new Unsubscriber(() => _observers.Remove(observer));
        }

        protected void Notify(T Subject)
        {
            foreach (var o in _observers)
                o.OnNext(Subject);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
