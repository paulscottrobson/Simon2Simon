using NAudio.Wave;

namespace SimonEm
{
	public class SampleProvider : ISampleProvider
	{
		WaveFormat waveFormat;
		SimonHardware simon;

		public SampleProvider(SimonHardware simon)
		{
			//sound sample frequency is set to match cpu frequency
			waveFormat = WaveFormat.CreateIeeeFloatWaveFormat(44100, 1);
			this.simon = simon;
		}

		public int Read(float[] buffer, int offset, int count)
		{
			//is there enough samples to wrote something?
			if ((simon.SoundTail - simon.SoundHead) >= count)
			{
				//catch up any delay
				if ((simon.SoundTail - simon.SoundHead) > count * 3)
				{
					simon.SoundHead = simon.SoundTail - count;
				}

				//wrote samples
				for (int sampleCount = 0; sampleCount < count; sampleCount++)
				{
					buffer[sampleCount + offset] =
						(simon.SoundBuffer[simon.SoundHead % simon.SoundBuffer.Length]
						+ simon.SoundBuffer[(simon.SoundHead + 1) % simon.SoundBuffer.Length]) / 8.0f;
					simon.SoundHead++;
				}
			}

			return count;
		}

		public WaveFormat WaveFormat
		{
			get
			{
				return waveFormat;
			}
		}
	}
}
