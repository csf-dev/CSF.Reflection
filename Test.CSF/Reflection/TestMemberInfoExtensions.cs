using System;
using NUnit.Framework;
using CSF.Reflection;
using System.Reflection;
using System.Collections.Generic;

namespace Test.CSF.Reflection
{
  [TestFixture]
  public class TestMemberInfoExtensions
  {
    #region tests
    
    [Test]
    public void TestGetAttribute()
    {
      SampleAttribute attrib;
      MemberInfo member;
      
      member = typeof(FooClass);
      attrib = member.GetAttribute<SampleAttribute>();
      Assert.IsNotNull(attrib, "Attribute is not null");
      Assert.AreEqual(23, attrib.Value, "Attribute value is correct");
      
      member = StaticReflectionUtility.GetMember<FooClass>(x => x.Bar);
      attrib = member.GetAttribute<SampleAttribute>();
      Assert.IsNotNull(attrib, "Attribute is not null (property)");
      Assert.AreEqual(3, attrib.Value, "Attribute value is correct (property)");
    }
    
    [Test]
    public void TestGetAttributeEnum()
    {
      SampleAttribute attrib;
      MemberInfo member;
      
      member = typeof(FooEnum);
      attrib = member.GetAttribute<SampleAttribute>();
      Assert.IsNull(attrib, "Attribute is null");
      
      member = FooEnum.Bar.GetFieldInfo();
      attrib = member.GetAttribute<SampleAttribute>();
      Assert.IsNotNull(attrib, "Attribute is not null (property)");
      Assert.AreEqual(6, attrib.Value, "Attribute value is correct (property)");
    }
    
    [Test]
    public void TestGetAttributes()
    {
      IList<SampleAttribute> attrib;
      MemberInfo member;
      
      member = StaticReflectionUtility.GetMember<FooClass>(x => x.Baz);
      attrib = member.GetAttributes<SampleAttribute>();
      Assert.IsNotNull(attrib, "Attributes collection is not null");
      Assert.AreEqual(2, attrib.Count, "Attributes collection has correct count");
      Assert.IsTrue(attrib.Contains(new SampleAttribute(18)), "Contains 18");
      Assert.IsTrue(attrib.Contains(new SampleAttribute(19)), "Contains 19");
    }
    
    [Test]
    public void TestGetAttributesEnum()
    {
      IList<SampleAttribute> attrib;
      MemberInfo member;
      
      member = typeof(FooEnum);
      attrib = member.GetAttributes<SampleAttribute>();
      Assert.IsNotNull(attrib, "Attributes collection is not null");
      Assert.AreEqual(0, attrib.Count, "Attributes collection is empty");
      
      member = FooEnum.Baz.GetFieldInfo();
      attrib = member.GetAttributes<SampleAttribute>();
      Assert.IsNotNull(attrib, "Attribute is not null (property)");
      Assert.AreEqual(2, attrib.Count, "Attributes collection has correct count");
      Assert.IsTrue(attrib.Contains(new SampleAttribute(4)), "Contains 4");
      Assert.IsTrue(attrib.Contains(new SampleAttribute(5)), "Contains 5");
    }
    
    #endregion
    
    #region contained types
    
    [Sample(23)]
    class FooClass
    {
      [Sample(3)]
      public string Bar
      {
        get;
        set;
      }
      
      [Sample(18)]
      [Sample(19)]
      public string Baz
      {
        get;
        set;
      }
    }
    
    enum FooEnum : int
    {
      [Sample(6)]
      Bar,
      
      [Sample(4)]
      [Sample(5)]
      Baz
    }
    
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    class SampleAttribute : Attribute
    {
      public int Value
      {
        get;
        private set;
      }
      
      public SampleAttribute(int value)
      {
        this.Value = value;
      }
      
      public override bool Equals (object obj)
      {
        return ((obj is SampleAttribute) && ((SampleAttribute) obj).Value == this.Value);
      }
      
      public override int GetHashCode ()
      {
        return this.Value;
      }
    }
    
    #endregion
  }
}
