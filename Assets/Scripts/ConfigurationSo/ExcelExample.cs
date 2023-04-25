//----------------------------------------------
//    Auto Generated. DO NOT edit manually!
//----------------------------------------------

#pragma warning disable 649

using System;
using UnityEngine;

public partial class ExcelExample : ScriptableObject {

	[NonSerialized]
	private int mVersion = 1;

	[SerializeField]
	private Student[] _StudentItems;

	public Student GetStudent(int id) {
		int min = 0;
		int max = _StudentItems.Length;
		while (min < max) {
			int index = (min + max) >> 1;
			Student item = _StudentItems[index];
			if (item.id == id) { return item.Init(mVersion, DataGetterObject); }
			if (id < item.id) {
				max = index;
			} else {
				min = index + 1;
			}
		}
		return null;
	}

	public void Reset() {
		mVersion++;
	}

	public interface IDataGetter {
		Student GetStudent(int id);
	}

	private class DataGetter : IDataGetter {
		private Func<int, Student> _GetStudent;
		public Student GetStudent(int id) {
			return _GetStudent(id);
		}
		public DataGetter(Func<int, Student> getStudent) {
			_GetStudent = getStudent;
		}
	}

	[NonSerialized]
	private DataGetter mDataGetterObject;
	private DataGetter DataGetterObject {
		get {
			if (mDataGetterObject == null) {
				mDataGetterObject = new DataGetter(GetStudent);
			}
			return mDataGetterObject;
		}
	}
}

[Serializable]
public class Student {

	[SerializeField]
	private int _Id;
	public int id { get { return _Id; } }

	[SerializeField]
	private string _Name;
	public string name { get { return _Name; } }

	[SerializeField]
	private string _Nationality;
	public string nationality { get { return _Nationality; } }

	[SerializeField]
	private int _Grade;
	public int grade { get { return _Grade; } }

	[SerializeField]
	private int _Class_level;
	public int class_level { get { return _Class_level; } }

	[SerializeField]
	private string _Birthday;
	public string birthday { get { return _Birthday; } }

	[SerializeField]
	private int[] _Favourite_numbers;
	public int[] favourite_numbers { get { return _Favourite_numbers; } }

	[SerializeField]
	private string[] _Hobbies;
	public string[] hobbies { get { return _Hobbies; } }

	[NonSerialized]
	private int mVersion = 0;
	public Student Init(int version, ExcelExample.IDataGetter getter) {
		if (mVersion == version) { return this; }
		mVersion = version;
		return this;
	}

	public override string ToString() {
		return string.Format("[Student]{{id:{0}, name:{1}, nationality:{2}, grade:{3}, class_level:{4}, birthday:{5}, favourite_numbers:{6}, hobbies:{7}}}",
			id, name, nationality, grade, class_level, birthday, array2string(favourite_numbers), array2string(hobbies));
	}

	private string array2string(Array array) {
		int len = array.Length;
		string[] strs = new string[len];
		for (int i = 0; i < len; i++) {
			strs[i] = string.Format("{0}", array.GetValue(i));
		}
		return string.Concat("[", string.Join(", ", strs), "]");
	}

}

