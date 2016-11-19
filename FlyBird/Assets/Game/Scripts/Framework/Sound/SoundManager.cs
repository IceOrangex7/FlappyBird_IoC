
/*
	脚本名称 : SoundManager.cs

	创建人 : #AuthorName#

	创建时间 : #CreateTime#

*/

using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	private static SoundManager _instance;
	public static SoundManager Instance{get{return _instance; }}


	private AudioSource audioSourece_BG;
	private float _bgmvolumn=0.5f;
	private float _sevolumn=0.5f;
	private float _voicevolumn=0.5f;
	private bool _isOpenBGM=true;
	private bool _isOpenSE=true;
	private bool _isOpenVC=true;

	public string ResourecesDir="Sounds";
	public string MusicDir="Music";
	public string SoundDir="Sound";
	public string VoiceDir="Voice";


	void Awake(){
		_instance=this;
		audioSourece_BG = gameObject.AddComponent<AudioSource> ();
		audioSourece_BG.loop = true;
		audioSourece_BG.playOnAwake = false;
		BGVolumn = 0.5f;
		SEVolumn = 0.5f;
		VoiceVolumn = 0.5f;
	}

	/// <summary>
	/// 背景音乐音量
	/// </summary>
	/// <value>The background volumn.</value>
	public float BGVolumn {
		get { 
			if (_isOpenBGM) {
				return audioSourece_BG.volume; 
			} else {
				return _bgmvolumn;
			}
		}
		set { 
			if (_isOpenBGM) {
				audioSourece_BG.volume = value; 
				_bgmvolumn = value;
			} else {
				_bgmvolumn = value;
			}
		}
	}
	public void CloseOpenBG(bool BGstate){
		_isOpenBGM = BGstate;
		if (!_isOpenBGM) {
			audioSourece_BG.volume = 0;
		} else {
			audioSourece_BG.volume = _bgmvolumn;
		}
	}

	/// <summary>
	/// 音效音量
	/// </summary>
	/// <value>The SE volumn.</value>
	public float SEVolumn {
		get{ return _sevolumn; }
		set{ _sevolumn = value; }
	}

	public void CloseOpenSE(bool SEstate){
		_isOpenSE = SEstate;
	}

	/// <summary>
	/// 配音音量
	/// </summary>
	/// <value>The voice volumn.</value>
	public float VoiceVolumn {
		get{ return _voicevolumn; }
		set{ _voicevolumn = value; }
	}

	public void CloseOpenVC(bool VCstate){
		_isOpenVC = VCstate;
	}

	/// <summary>
	/// 根据音乐名播放音乐
	/// </summary>
	/// <param name="name"> 音乐名 </param>
	public void PlayMusicByName(string name){
		string path = ResourecesDir + MusicDir + name;
		AudioClip clip = Resources.Load<AudioClip> (path);
		if (clip != null) {
			audioSourece_BG.clip = clip;
			audioSourece_BG.Play ();
		}
	}

	/// <summary>
	/// 停止播放音乐
	/// </summary>
	public void StopMusic(){
		audioSourece_BG.Stop ();
		audioSourece_BG.clip = null;
	}

	/// <summary>
	/// 根据音效名播放音效
	/// </summary>
	/// <param name="name">Name.</param>
	public void PlayAudioByName(string name){
		if (_isOpenSE) {
			string path = ResourecesDir + SoundDir + name;
			AudioClip clip = Resources.Load<AudioClip> (path);
			if (clip != null) {
				if (Camera.main.transform ==null) {
					return;
				}
				AudioSource.PlayClipAtPoint (clip, Camera.main.transform.position, SEVolumn);
			}
		}
	}

	/// <summary>
	/// 根据配音名播放配音
	/// </summary>
	/// <param name="name">Name.</param>
	public void PlayVoiceByName(string name){
		if (_isOpenVC) {
			string path = ResourecesDir + VoiceDir + name;
			AudioClip clip = Resources.Load<AudioClip> (path);
			if (clip != null) {
				if (Camera.main.transform ==null) {
					return;
				}
				AudioSource.PlayClipAtPoint (clip, Camera.main.transform.position, VoiceVolumn);
			}
		}
	}

}
