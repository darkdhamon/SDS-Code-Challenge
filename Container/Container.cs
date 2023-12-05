using System;
using System.Collections.Generic;

namespace DeveloperSample.Container
{
    public class Container
    {
        //private Dictionary<Type, Type> _implementationTypeFor { get; } = new();
        private Dictionary<Type, object> _singletonFor { get; } = new();

        public void Bind(Type interfaceType, Type implementationType)
        {
            //Idea 1) MVP for tests
            //_implementationTypeFor[interfaceType] = implementationType;
            
            //Idea 2) Why would you use this... probably to track singleton instances
            _singletonFor[interfaceType] = Activator.CreateInstance(implementationType);
        }

        public T Get<T>()
        {
            //var implementation = Activator.CreateInstance(_implementationTypeFor[typeof(T)]);
            //return (T)implementation;
            return (T)_singletonFor[typeof(T)];
        }
    }
}