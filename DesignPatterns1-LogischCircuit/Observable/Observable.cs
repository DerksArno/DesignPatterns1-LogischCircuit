using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            // TODO: We moeten bijhouden wie ons in de gaten houdt.
            // TODO: Stop de observer dus in de lijst met observers. We weten dan
            // welke objecten we allemaal een seintje moeten geven.
            // Daarna geven we een object terug.
            // Als dat object gedisposed wordt geven wij
            // de bovenstaande observer geen seintjes meer.
            _observers.Add(observer);


            return new Unsubscriber(() => _observers.Remove(observer));
        }

        protected void Notify(T Subject)
        {
            // TODO: Hier moeten we iedere observer die ons in de gaten houdt een seintje geven dat we een nieuwe waarde hebben. We roepen dus hun OnNext methode aan.
            foreach (var o in _observers)
                o.OnNext(Subject);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
