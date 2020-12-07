
FROM golang:1.15.5-alpine3.12
RUN mkdir /app
ADD . /app
WORKDIR /app
EXPOSE 8085
RUN go build -o Ping .
CMD ["/app/Ping"]