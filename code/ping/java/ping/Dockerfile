FROM openjdk:11
ADD target/java_ping_docker.jar java_ping_docker.jar
EXPOSE 8085
ENTRYPOINT ["java", "-jar", "java_ping_docker.jar"]