del WordCount.jar

javac -classpath ../lib/hadoop-mapreduce-client-core-2.7.1.jar;../lib/hadoop-common-2.7.1.jar WordCount.java

jar cf WordCount.jar *.class

del *.class
