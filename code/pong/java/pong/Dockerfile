FROM openjdk:11
ADD target/java_pong_docker.jar java_pong_docker.jar
EXPOSE 8086
ENTRYPOINT ["java", "-jar", "java_pong_docker.jar"]