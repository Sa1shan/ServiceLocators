using System;
using System.Collections.Generic;
using _Source.interfaces;

namespace _Source.MainLogic
{
    public class ServiceLocator : IService
    {
        private readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();

        public ServiceLocator(params (Type type, object instance)[] initialServices)
        {
            foreach (var pair in initialServices)
            {
                _services[pair.type] = pair.instance;
            }
        }

        public void Register<T>(T service) where T : class
        {
            var t = typeof(T);
            _services[t] = service;
        }

        public T GetService<T>() where T : class
        {
            var t = typeof(T);
            if (_services.TryGetValue(t, out var instance))
            {
                return instance as T;
            }

            return null;
        }
    }
}