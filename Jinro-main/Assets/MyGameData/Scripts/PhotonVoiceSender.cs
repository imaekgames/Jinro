using UnityEngine;
using System.Collections;
using DaikonForge.VoIP;

namespace YUKI
{
	public class PhotonVoiceSender : VoiceControllerBase
	{
		Animator anim;

		private PhotonView cachedPhotonView;
		public PhotonView photonView
        {
            get
            {
                if( cachedPhotonView == null )
                    cachedPhotonView = GetComponent<PhotonView>();
                return cachedPhotonView;
            }
        }

		void Start()
		{
			if (photonView.isMine) Debug.Log("isMine");
		}

		public override bool IsLocal
		{
			get
			{
				return photonView.isMine;
			}
		}

		protected override void Awake()
		{
			base.Awake();

			VoiceControllerCollection<PhotonVoiceSender>.RegisterVoiceController(this);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();

			VoiceControllerCollection<PhotonVoiceSender>.UnregisterVoiceController(this);
		}

		protected override void OnAudioDataEncoded(VoicePacketWrapper encodedFrame)
		{
			byte[] headers = encodedFrame.ObtainHeaders();
			photonView.RPC("vc", PhotonTargets.All, headers, encodedFrame.RawData);
			encodedFrame.ReleaseHeaders();
		}

		[PunRPC]
		void vc(byte[] headers, byte[] rawData)
		{
			VoicePacketWrapper packet = new VoicePacketWrapper(headers, rawData);
			ReceiveAudioData(packet);
			Debug.Log("Catch Voice Data");
		}
	}
}
