cd RealEstatesFilter
call compile.cmd
cd ..

rm -rf input
rm -rf output

call hadoop fs -mkdir input
call hadoop fs -put *.csv input

call hadoop jar RealEstatesFilter\RealEstatesFilter.jar RealEstatesFilter input output

call hadoop fs -cat output\*
