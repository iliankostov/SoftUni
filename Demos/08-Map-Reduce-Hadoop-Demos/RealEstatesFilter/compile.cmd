del WordCount.jar

javac -classpath ../lib/hadoop-mapreduce-client-core-2.7.1.jar;../lib/hadoop-common-2.7.1.jar RealEstatesFilter.java

jar cf RealEstatesFilter.jar *.class

del *.class
