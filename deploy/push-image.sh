#!/bin/sh

docker tag url2pdfapi:latest baron123.azurecr.io/url2pdf/url2pdfapi:$1
docker login baron123.azurecr.io -u $DOCKER_USER -p $DOCKER_PASS        
docker push baron123.azurecr.io/url2pdf/url2pdfapi

