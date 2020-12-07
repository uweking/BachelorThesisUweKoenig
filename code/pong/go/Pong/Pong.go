package main

import (
	"io/ioutil"
	"log"
	"net/http"
)

var counter = 0

func getAllCustomers(w http.ResponseWriter, r *http.Request) {
	body, _ := ioutil.ReadAll(r.Body)
	w.Write(body)
}

func main() {
	router := http.NewServeMux()
	router.HandleFunc("/pong", getAllCustomers)
	log.Println("CustomerServer: Listening on http://localhost:8086/pong")
	log.Fatal(http.ListenAndServe(":8086", router))
}