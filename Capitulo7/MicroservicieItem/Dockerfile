FROM openjdk:17
WORKDIR /app
COPY ./target/MicroservicieItem-1.0.0.jar item.jar
EXPOSE 8081
ENTRYPOINT ["java","-jar","item.jar"]