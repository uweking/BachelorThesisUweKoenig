package main

import (
	"bytes"
	"io/ioutil"
	"log"
	"net/http"
	"strconv"
	"time"
)

func getAllCustomers(w http.ResponseWriter, r *http.Request) {

	var maxCount = 500
	var wrongCL = 0
	var body, _ = ioutil.ReadAll(r.Body)
	reqCL := r.ContentLength
	start := time.Now()
	//host.docker.internal
	for i := 0; i < maxCount; i++ {
		req, _ :=  http.Post("http://172.17.0.2:8086/pong", "text/plain", bytes.NewReader(body))
		resBody, _ := ioutil.ReadAll(req.Body)
		resCL := len(resBody)
		if(int(reqCL) != resCL){
			wrongCL++
		}
	}
	end := time.Now()
	elapsed := end.Sub(start).Milliseconds()

	ret := strconv.Itoa(int(reqCL)) + "," + strconv.Itoa(int(elapsed)) + "," + strconv.Itoa(int(wrongCL))
	w.Write([]byte(ret))
}

func main() {
	router := http.NewServeMux()
	router.HandleFunc("/ping", getAllCustomers)
	log.Println("CustomerServer: Listening on http://localhost:8085/ping")
	log.Fatal(http.ListenAndServe(":8085", router))
}