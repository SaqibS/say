﻿namespace Say
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Speech.Synthesis;
    using NDesk.Options;

    internal static class Program
    {
        private static OptionSet options;
        private static SpeechSynthesizer synth;

        internal static void Main(string[] args)
        {
            try
            {
                synth = new SpeechSynthesizer();
                string textToSpeak = "";

                options = new OptionSet
            {
                { "v|voice=", "Use the specified {voice} (surround the name in quotes if it contains spaces).", x => { synth.SelectVoice(x); } },
                { "r|rate=", "Speak at the specified {rate} (0-20).", x => { SetRate(x); } },
                { "f|input-file=", "Speak the contents of {file.txt}.", x => { textToSpeak=File.ReadAllText(x); } },
                { "o|output-file=", "Save the audio to {file.wav}.", x => { synth.SetOutputToWaveFile(x); } },
                { "l|list-voices", "List available voices.", x => { ListVoices(); return; } },
                { "h|help", "Print this help message and exit.", x => { PrintHelpMessage(); return; } }
            };

                List<string> extra = options.Parse(args);

                if (textToSpeak == null || textToSpeak.Trim().Length == 0)
                {
                    if (extra.Count > 0)
                    {
                        textToSpeak = string.Join(" ", extra.ToArray());
                    }
                    else
                    {
                        textToSpeak = Console.In.ReadToEnd();
                    }
                }

                if (textToSpeak == null || textToSpeak.Trim().Length == 0)
                {
                    Console.WriteLine("Error: could not find text to speak.");
                    Console.WriteLine();
                    PrintHelpMessage();
                    return;
                }

                synth.Speak(textToSpeak);
            }
            catch (Exception x)
            {
                Console.WriteLine("Error: {0} - {1}", x.GetType().Name, x.Message);
                Console.WriteLine();
                PrintHelpMessage();
            }
        }

        private static void SetRate(string input)
        {
            int value = int.Parse(input);
            if (value < 0 || value > 20)
            {
                throw new ArgumentOutOfRangeException("input", "Rate must be between 0 and 20 (default=10).");
            }

            synth.Rate = value - 10;
        }

        private static void ListVoices()
        {
            foreach (InstalledVoice voice in synth.GetInstalledVoices())
            {
                Console.WriteLine(voice.VoiceInfo.Name);
            }
        }

        private static void PrintHelpMessage()
        {
            Console.WriteLine("Usage:");
            options.WriteOptionDescriptions(Console.Out);
        }
    }
}
