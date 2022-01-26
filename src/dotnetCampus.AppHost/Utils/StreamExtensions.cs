// Modified From: https://stackoverflow.com/a/1472689/6233938

namespace dotnetCampus.AppHosting.Utils;

static class StreamExtensions
{
    public static bool TryMoveToBytes(this Stream stream, byte[] pattern)
    {
        if (pattern.Length > stream.Length)
        {
            return false;
        }

        var buffer = new byte[pattern.Length];
        var bs = new BufferedStream(stream, pattern.Length);
        while (bs.Read(buffer, 0, pattern.Length) == pattern.Length)
        {
            if (pattern.SequenceEqual(buffer))
            {
                stream.Position = bs.Position - pattern.Length;
                return true;
            }
            else
            {
                bs.Position -= pattern.Length - PadLeftSequence(buffer, pattern);
            }
        }

        return false;
    }

    private static int PadLeftSequence(byte[] bytes, byte[] seqBytes)
    {
        var i = 1;
        while (i < bytes.Length)
        {
            var n = bytes.Length - i;
            var aux1 = new byte[n];
            var aux2 = new byte[n];
            Array.Copy(bytes, i, aux1, 0, n);
            Array.Copy(seqBytes, aux2, n);
            if (aux1.SequenceEqual(aux2))
            {
                return i;
            }

            i++;
        }
        return i;
    }
}
