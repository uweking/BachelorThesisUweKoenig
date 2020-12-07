package com.example.ping;

import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import java.io.IOException;
import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;

@RestController
public class PingController {

    HttpClient client = null;
    HttpResponse<?> response = null;
    HttpRequest request = null;

    public PingController(){
        client = HttpClient.newBuilder().build();
    }

    @PostMapping("/ping")
    public String index(@RequestBody String s) {

        String ret = "";
        request = HttpRequest.newBuilder()
                .version(HttpClient.Version.HTTP_1_1)
                .uri(URI.create("http://host.docker.internal:8086/pong"))//host.docker.internal
                .POST(HttpRequest.BodyPublishers.ofString(s))
                .build();

        int maxCount = 500;
        int bodyCL = s.length();
        int wrong = 0;

        long start = System.currentTimeMillis();
        for(int i = 0; i < maxCount; i++){
            try {
                response = client.send(request, HttpResponse.BodyHandlers.ofString());
                if(bodyCL != response.body().toString().length()){
                    wrong++;
                }
            } catch (IOException e) {
                e.printStackTrace();
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
        long end = System.currentTimeMillis();

        return bodyCL + "," + (end - start) + "," + wrong;
    }
}