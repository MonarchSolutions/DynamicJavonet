using System.Dynamic;
using JavonetBridge.Api;

namespace DynamicJavonet
{
    public class DJObject : DynamicObject
    {
        public JObject JObject { get; set; }

        public DJObject(JObject obj)
        {
            JObject = obj;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = JObject.Get<object>(binder.Name).ToDJ();
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            JObject.Set(binder.Name, value.AsParameter());
            return true;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            result = JObject.Invoke<object>(binder.Name, args.AsParameters()).ToDJ();
            return true;
        }
    }
}