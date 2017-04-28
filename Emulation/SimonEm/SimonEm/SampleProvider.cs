﻿using System;
using System.Diagnostics;
using NAudio.Wave;
using SimonEm;

namespace SimonEm
{
	/// <summary>
	/// Description of SoundGenerator.
	/// </summary>
	public class SampleProvider : ISampleProvider {
			
		WaveFormat waveFormat;		
		SimonHardware simon;
				
		public SampleProvider(SimonHardware simon)
		{			
			//sound sample frequency is set to half cpu frequency
			waveFormat = WaveFormat.CreateIeeeFloatWaveFormat(12500, 1);
			this.simon = simon;
		}	

		public int Read(float[] buffer, int offset, int count)
		{						
			//is there enough samples to wrote something?
			if((simon.SoundTail - simon.SoundHead) >= count * 4)
			{
				//catch up any delay
				if((simon.SoundTail - simon.SoundHead) >= count * 8)
				{
					simon.SoundHead = simon.SoundTail - (count * 6);
				}
				//wrote samples
				for (int sampleCount = 0; sampleCount < count; sampleCount++)
				{				
					buffer[sampleCount + offset] = simon.SoundBuffer[simon.SoundHead%simon.SoundBuffer.Length] * 0.25f;
					simon.SoundHead	+= 4;
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
