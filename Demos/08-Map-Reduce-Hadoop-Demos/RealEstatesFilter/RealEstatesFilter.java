import java.io.IOException;

import org.apache.hadoop.conf.Configuration;
import org.apache.hadoop.fs.Path;
import org.apache.hadoop.io.LongWritable;
import org.apache.hadoop.io.Text;
import org.apache.hadoop.mapreduce.Job;
import org.apache.hadoop.mapreduce.Mapper;
import org.apache.hadoop.mapreduce.Reducer;
import org.apache.hadoop.mapreduce.lib.input.FileInputFormat;
import org.apache.hadoop.mapreduce.lib.output.FileOutputFormat;

public class RealEstatesFilter {

	public static class RealEstatesFilterMapper 
			extends Mapper<Object, Text, Text, LongWritable> {

		private Text city = new Text();
		private LongWritable price = new LongWritable();

		public void map(Object offset, Text inputCSVLine, Context context)
				throws IOException, InterruptedException {
			if (((LongWritable)offset).get() == 0) {
				// Skip the header line (it starts at offset 0)
				return;
			}
			String[] fields = inputCSVLine.toString().split(",");
			String estateCity = fields[1];
			int estatePrice = Integer.parseInt(fields[9]);
			if (estatePrice > 100000 && estatePrice < 200000) {
				city.set(estateCity);
				price.set(estatePrice);
				context.write(city, price);
			}
		}
	}

	public static class CitiesReducer
			extends Reducer<Text, LongWritable, Text, LongWritable> {
		private LongWritable result = new LongWritable();
	
		public void reduce(Text city, Iterable<LongWritable> prices,
				Context context) throws IOException, InterruptedException {
			long sum = 0;
			for (LongWritable val : prices) {
				sum += val.get();
			}
			result.set(sum);
			context.write(city, result);
		}
	}

	public static void main(String[] args) throws Exception {
		Configuration conf = new Configuration();
		Job job = Job.getInstance(conf, "real estates filter");
		job.setJarByClass(RealEstatesFilter.class);
		job.setMapperClass(RealEstatesFilterMapper.class);
		job.setCombinerClass(CitiesReducer.class);
		job.setReducerClass(CitiesReducer.class);
		job.setOutputKeyClass(Text.class);
		job.setOutputValueClass(LongWritable.class);
		System.out.println("Input format class: " + job.getInputFormatClass());
		FileInputFormat.addInputPath(job, new Path(args[0]));
		FileOutputFormat.setOutputPath(job, new Path(args[1]));
		System.exit(job.waitForCompletion(true) ? 0 : 1);
	}
}
