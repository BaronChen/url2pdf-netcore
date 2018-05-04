#!/bin/sh

eval "$(aws ecr get-login --region=ap-southeast-2 --no-include-email)"

docker tag url2pdfapi:latest 677611292116.dkr.ecr.ap-southeast-2.amazonaws.com/url2pdf-api:$1
docker push 677611292116.dkr.ecr.ap-southeast-2.amazonaws.com/url2pdf-api