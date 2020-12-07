package Client;


import java.io.IOException;


public class Client {



    public static void main(String[] args) throws IOException, InterruptedException {

        DockerStartingThread t1 = new DockerStartingThread("aspMultipleDocker", 1, 8085);
        t1.start();

    }
}