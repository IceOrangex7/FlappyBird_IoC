
/*
	脚本名称 : ReuseableObject.cs

	创建人 : #AuthorName#

	创建时间 : #CreateTime#

*/

using UnityEngine;
using System.Collections;

public abstract class ReuseableObject : MonoBehaviour,IReuseable {
	
	public abstract void BeforeGetObject ();

	public abstract void BeforeHideObject ();

}
