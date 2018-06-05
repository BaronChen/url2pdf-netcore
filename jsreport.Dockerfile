From jsreport/jsreport:2.0.0-full
EXPOSE 5488

RUN apt-get -y update
RUN apt-get -y install  libssl1.0-dev

CMD ["bash", "/app/run.sh"]
