Results:
---------------------------------------------------------------------------------------------------------------------------------------------
                                                 THE ASSEMBLY WAS LOADED SUCCESSFULLY!

namespace Sample
{
     interface IMe
     {
          METHODS:
                                          public abstract virtual String Hello(String a, Byte d);
                                          public abstract virtual Void Proter();
          FIELDS:
          PROPERTIES:
          CONSTRUCTORS:
     }

     class Sample
     {
          METHODS:
                                          private Double[] get_Count();
                                          private Void set_Count(Double[] value);
                                          public virtual Void Save();
                                          public abstract virtual String MyMethod();
                                          public virtual String Hello(String a, Byte b);
                                          public virtual Void Proter();
                                          public virtual Boolean Equals(Object obj);
                                          public virtual Int32 GetHashCode();
                                          virtual Void Finalize();
                                          public Type GetType();
                                          Object MemberwiseClone();
                                          public virtual String ToString();
          FIELDS:
                                          private Double[] <Count>k__BackingField;
          PROPERTIES:
                                          Double[] Count;
          CONSTRUCTORS:
                                          .ctor();
     }

     struct enum Enum
     {
          METHODS:
                                          Object GetValue();
                                          public virtual Int32 GetHashCode();
                                          public virtual String ToString();
                                          public virtual String ToString(String format, IFormatProvider provider);
                                          public virtual Int32 CompareTo(Object target);
                                          public virtual String ToString(IFormatProvider provider);
                                          public Boolean HasFlag(Enum flag);
                                          public virtual TypeCode GetTypeCode();
                                          private virtual Boolean System.IConvertible.ToBoolean(IFormatProvider provider);
                                          private virtual Char System.IConvertible.ToChar(IFormatProvider provider);
                                          private virtual SByte System.IConvertible.ToSByte(IFormatProvider provider);
                                          private virtual Byte System.IConvertible.ToByte(IFormatProvider provider);
                                          private virtual Int16 System.IConvertible.ToInt16(IFormatProvider provider);
                                          private virtual UInt16 System.IConvertible.ToUInt16(IFormatProvider provider);
                                          private virtual Int32 System.IConvertible.ToInt32(IFormatProvider provider);
                                          private virtual UInt32 System.IConvertible.ToUInt32(IFormatProvider provider);
                                          private virtual Int64 System.IConvertible.ToInt64(IFormatProvider provider);
                                          private virtual UInt64 System.IConvertible.ToUInt64(IFormatProvider provider);
                                          private virtual Single System.IConvertible.ToSingle(IFormatProvider provider);
                                          private virtual Double System.IConvertible.ToDouble(IFormatProvider provider);
                                          private virtual Decimal System.IConvertible.ToDecimal(IFormatProvider provider);
                                          private virtual DateTime System.IConvertible.ToDateTime(IFormatProvider provider);
                                          private virtual Object System.IConvertible.ToType(Type type, IFormatProvider provider);
                                          public virtual Boolean Equals(Object obj);
                                          public String ToString(String format);
                                          virtual Void Finalize();
                                          public Type GetType();
                                          Object MemberwiseClone();
          FIELDS:
                                          public Int32 value__;
                                          public static Enum First;
                                          public static Enum Second;
          PROPERTIES:
          CONSTRUCTORS:
     }

     struct Metro
     {
          METHODS:
                                          public Int32 get_Age();
                                          private Void Mehhh();
                                          public virtual Boolean Equals(Object obj);
                                          public virtual String ToString();
                                          public virtual Int32 GetHashCode();
                                          virtual Void Finalize();
                                          public Type GetType();
                                          Object MemberwiseClone();
          FIELDS:
                                          private Int32 <Age>k__BackingField;
                                          private String Name;
          PROPERTIES:
                                          Int32 Age;
          CONSTRUCTORS:
     }

     class Metrohod
     {
          METHODS:
                                          private static Byte[] Loops();
                                          public virtual Boolean Equals(Object obj);
                                          public virtual Int32 GetHashCode();
                                          virtual Void Finalize();
                                          public Type GetType();
                                          Object MemberwiseClone();
                                          public virtual String ToString();
          FIELDS:
          PROPERTIES:
          CONSTRUCTORS:
                                          private static .cctor();
     }

     class MyClass`2
     {
          METHODS:
                                          private Void Krot(T a, P b);
                                          public virtual Boolean Equals(Object obj);
                                          public virtual Int32 GetHashCode();
                                          virtual Void Finalize();
                                          public Type GetType();
                                          Object MemberwiseClone();
                                          public virtual String ToString();
          FIELDS:
          PROPERTIES:
          CONSTRUCTORS:
                                          public .ctor();
     }

     class MyDelegate
     {
          METHODS:
                                          public virtual Void Invoke();
                                          public virtual IAsyncResult BeginInvoke(AsyncCallback callback, Object object);
                                          public virtual Void EndInvoke(IAsyncResult result);
                                          Boolean IsUnmanagedFunctionPtr();
                                          Boolean InvocationListLogicallyNull();
                                          public virtual Void GetObjectData(SerializationInfo info, StreamingContext context);
                                          public virtual Boolean Equals(Object obj);
                                          MulticastDelegate NewMulticastDelegate(Object[] invocationList, Int32 invocationCount);
                                          Void StoreDynamicMethod(MethodInfo dynamicMethod);
                                          virtual Delegate CombineImpl(Delegate follow);
                                          virtual Delegate RemoveImpl(Delegate value);
                                          public virtual Delegate[] GetInvocationList();
                                          public virtual Int32 GetHashCode();
                                          virtual Object GetTarget();
                                          virtual MethodInfo GetMethodImpl();
                                          public Object DynamicInvoke(Object[] args);
                                          virtual Object DynamicInvokeImpl(Object[] args);
                                          public MethodInfo get_Method();
                                          public Object get_Target();
                                          public virtual Object Clone();
                                          IntPtr GetCallStub(IntPtr methodPtr);
                                          IntPtr GetMulticastInvoke();
                                          IntPtr GetInvokeMethod();
                                          IRuntimeMethodInfo FindMethodHandle();
                                          IntPtr AdjustTarget(Object target, IntPtr methodPtr);
                                          virtual Void Finalize();
                                          public Type GetType();
                                          Object MemberwiseClone();
                                          public virtual String ToString();
          FIELDS:
                                          Object _target;
                                          Object _methodBase;
                                          IntPtr _methodPtr;
                                          IntPtr _methodPtrAux;
          PROPERTIES:
                                          MethodInfo Method;
                                          Object Target;
          CONSTRUCTORS:
                                          public .ctor(Object object, IntPtr method);
     }

     class Sample2
     {
          METHODS:
                                          public virtual Void Save();
                                          public virtual String MyMethod();
                                          public Void add_EventName(MyDelegate value);
                                          public Void remove_EventName(MyDelegate value);
                                          public virtual String Hello(String a, Byte b);
                                          public virtual Void Proter();
                                          public virtual Boolean Equals(Object obj);
                                          public virtual Int32 GetHashCode();
                                          virtual Void Finalize();
                                          public Type GetType();
                                          Object MemberwiseClone();
                                          public virtual String ToString();
          FIELDS:
                                          private MyDelegate EventName;
          PROPERTIES:
          CONSTRUCTORS:
                                          public .ctor(Int32 a, Double b);
     }

     class Program
     {
          METHODS:
                                          private static Void Main(String[] args);
                                          public virtual Boolean Equals(Object obj);
                                          public virtual Int32 GetHashCode();
                                          virtual Void Finalize();
                                          public Type GetType();
                                          Object MemberwiseClone();
                                          public virtual String ToString();
          FIELDS:
          PROPERTIES:
          CONSTRUCTORS:
                                          public .ctor();
     }

}
