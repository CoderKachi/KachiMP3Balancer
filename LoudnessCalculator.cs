using NAudio.Wave;

public static class LoudnessCalculator
{
    public static double Calculate(string path)
    {
        // Currently just using RMS -> dBFS
        using var reader = new AudioFileReader(path);

        float[] buffer = new float[4096];

        double sumSquared = 0;
        long totalSamples = 0;

        while (true)
        {
            int samplesRead = reader.Read(buffer, 0, buffer.Length);

            if (samplesRead <= 0) break;

            for (int i = 0; i < samplesRead; i++)
            {
                float sample = buffer[i];
                sumSquared = sumSquared + (sample * sample);
            }

            totalSamples += samplesRead;
        }

        double rms = Math.Sqrt(sumSquared / totalSamples);
        double db = 20 * Math.Log10(rms);

        return db;
    }  
}
