using ReflectionTry.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ReflectionTry
{
    public class FunctionData : Data, IHasParameters
    {
        private MethodInfo _methodInfo;
        private Data _myResult;

        public override Data ResultType => _myResult;

        public override bool CanContinue => _myResult.CanContinue;

        public override bool CanEnd => true;
        public override string GiveCode(bool isEnd)
        {
            if (isEnd)
            {
                return _methodInfo.Name+"();";
            }
            else
            {
                return _methodInfo.Name + "().";
            }
        }

        public override string Id { get; protected set; }

        public override string Name
        {
            get
            {
                var attrName = GetNameByAttributes(_methodInfo.GetCustomAttributes(true));
                return (attrName != null) ? attrName : _methodInfo.Name;
            }
        }

        public IEnumerable<ParameterInfo> Parameters
        {
            get
            {
                return _methodInfo.GetParameters();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public FunctionData(MethodInfo methodInfo, Type extendedType)
        {
            Id = "Func." + methodInfo.Name + "." + methodInfo.DeclaringType;
            _methodInfo = methodInfo;

            var returnType = (extendedType != null) ? extendedType : _methodInfo.ReturnType;
            if (returnType.IsPrimitive)
            {
                _myResult = new PrimitiveData(returnType);
            }
            else if (returnType.IsClass)
            {
                _myResult = new ClassData(false, returnType);
            }
            else
            {
                _myResult = new NoData();
            }
        }
        public override IEnumerable<Data> GetContinue() => _myResult.GetContinue();
    }
}