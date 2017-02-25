import java.io.IOException;

import org.apache.hadoop.conf.Configuration;
import org.apache.hadoop.fs.Path;
import org.apache.hadoop.io.IntWritable;
import org.apache.hadoop.io.Text;
import org.apache.hadoop.mapreduce.Job;
import org.apache.hadoop.mapreduce.Mapper;
import org.apache.hadoop.mapreduce.Reducer;
import org.apache.hadoop.mapreduce.lib.input.FileInputFormat;
import org.apache.hadoop.mapreduce.lib.output.FileOutputFormat;

public class WordCount {

	public static class WordCountMapper 
			extends Mapper<Object, Text, Text, IntWritable> {

		private static final IntWritable one = new IntWritable(1);
		private Text text = new Text();

		public void map(Object offset, Text docLine, Context context)
				throws IOException, InterruptedException {
			String[] words = docLine.toString().toLowerCase().split("\\W+");
			for (String word : words) {
				text.set(word);
				context.write(text, one);
			}
		}
	}

	public static class IntSumReducer
			extends Reducer<Text, IntWritable, Text, IntWritable> {
		
		private IntWritable result = new IntWritable();

		public void reduce(Text word, Iterable<IntWritable> counts, 
				Context context) throws IOException, InterruptedException {
			int sum = 0;
			for (IntWritable count : counts) {
				sum += count.get();
			}
			result.set(sum);
			context.write(word, result);
		}
	}

	public static void main(String[] args) throws Exception {
		Configuration conf = new Configuration();
		Job job = Job.getInstance(conf, "word count");
		job.setJarByClass(WordCount.class);
		job.setMapperClass(WordCountMapper.class);
		job.setCombinerClass(IntSumReducer.class);
		job.setReducerClass(IntSumReducer.class);
		job.setOutputKeyClass(Text.class);
		job.setOutputValueClass(IntWritable.class);
		FileInputFormat.addInputPath(job, new Path(args[0]));
		FileOutputFormat.setOutputPath(job, new Path(args[1]));
		System.exit(job.waitForCompletion(true) ? 0 : 1);
	}
}
