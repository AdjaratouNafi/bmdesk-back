FROM ubi8/ubi

WORKDIR /server

RUN yum update -y \
 && yum install dotnet-3.1.108-2.el8_2.x86_64 python36 -y \
 && pip3 install j2cli

COPY . /server

RUN dotnet build && chmod +x /server/entrypoint.sh

CMD /server/entrypoint.sh

EXPOSE 8080