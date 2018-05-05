#!/bin/bash

group_name="url2pdf"
location="southeastasia"
dns_label="url2pdf"
exists=`az group exists --name $group_name`
image="baron123.azurecr.io/url2pdf/url2pdfapi:$1"
continaer_name="url2pdfcontainer"

if [ $exists == "true" ]; then
    echo "resource group $group_name exists."
else
    echo "resource group $group_name not exists, creating resource group $group_name..."
    az group create --location $location --name $group_name
fi

az container create --resource-group $group_name --name $continaer_name --image $image --dns-name-label $dns_label --ports 80 --registry-username $DOCKER_USER --registry-password $DOCKER_PASS --cpu 1 --memory 1