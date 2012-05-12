# Say - Convert Text to Audible Speech

By default, the Windows TTS engine is used (as specified in Control Panel -> Text To Speech), however you can obtain both free and commercial TTS engines from various companies on the web.

## Usage

* -v, --voice=voice          Use the specified voice (surround the name in quotes if it contains spaces).
* -r, --rate=rate            Speak at the specified rate (0-20).
* -f, --input-file=file.txt  Speak the contents of file.txt.
* -o, --output-file=file.wav Save the audio to file.wav.
* -l, --list-voices          List available voices.
* -h, --help                 Print this help message and exit.

## Comments

To simply speak a specified string, you can type "say hello". To speak the contents of a text file, use "say -f filename.txt". Say.exe will also read text from standard input - so you can pipe the output of another command: "WhoAmI | Say".

To see which voices you have installed on your system, use "say -l". You can then specify the voice: 'say -v "Microsoft Anna"'. It is important to spell the name correctly, including spaces and capitals. As in this example, if the voice contains a space, you should surround it with quotes.

You can specify how fast the text should be spoken - "say -r 0" is the slowest, and "say -r 20" is the fastest. A value of 10 gives a standard speaking rate.

Finally, the audible speech can be saved in a wave (.wav) file: "say -f c:\filename.txt -o c:\filename.wav".

## Feedback

If you have any feedback, please email "me" at the domain SaqibShaikh.com.
