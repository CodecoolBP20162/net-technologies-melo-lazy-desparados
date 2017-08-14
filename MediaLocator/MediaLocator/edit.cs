using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace meLo



{
    class AudioSplitOutput

    {
        public string FileName;
        public ulong AudioTimeOffsetTotalMilliseconds = 0;

        private static List<AudioSplitOutput> SplitMp3File(string baseNameForSplits, string sourceFileName, string destinationPath)
        {
            List<AudioSplitOutput> outputAudioSplitList = new List<AudioSplitOutput>();

            int splitLength = 480; // seconds

            int secsOffset = 0;
            int splitIndex = 0;

            using (var reader = new Mp3FileReader(sourceFileName))
            {

                FileStream writer = null;
                Action createWriter = new Action(() => {
                    string newBaseNameForSplit = baseNameForSplits + "-" + (++splitIndex).ToString();
                    string newFileName = Path.Combine(destinationPath, newBaseNameForSplit + ".mp3");
                    if (File.Exists(newFileName))
                    {
                        File.Delete(newFileName);
                    }
                    writer = File.Create(newFileName);

                    AudioSplitOutput audioSplitOutput = new AudioSplitOutput();
                    audioSplitOutput.FileName = newFileName;
                    audioSplitOutput.AudioTimeOffsetTotalMilliseconds = ulong.Parse(reader.CurrentTime.TotalMilliseconds.ToString());
                    outputAudioSplitList.Add(audioSplitOutput);
                });

                Mp3Frame frame;
                while ((frame = reader.ReadNextFrame()) != null)
                {
                    if (writer == null) createWriter();

                    if ((int)reader.CurrentTime.TotalSeconds - secsOffset >= splitLength)
                    {
                        // time for a new file
                        writer.Dispose();
                        createWriter();
                        secsOffset = (int)reader.CurrentTime.TotalSeconds;
                    }

                    writer.Write(frame.RawData, 0, frame.RawData.Length);
                }
                if (writer != null) writer.Dispose();
            }
            return outputAudioSplitList;
        }

        
    }
}
