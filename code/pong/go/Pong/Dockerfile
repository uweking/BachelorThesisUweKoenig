FROM golang:1.15.5-alpine3.12
RUN mkdir /app
ADD . /app
WORKDIR /app
EXPOSE 8086
RUN go build -o Pong .
CMD ["/app/Pong"]