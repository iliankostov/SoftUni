cd WordCount
call compile.cmd
cd ..

rm -rf input
rm -rf output

call hadoop fs -mkdir input
call hadoop fs -put example*.txt input

call hadoop jar WordCount\WordCount.jar WordCount input output

call hadoop fs -cat output\*
