FROM mcr.microsoft.com/mssql/server:2019-latest

ENV SA_PASSWORD Twojastara0!
ENV ACCEPT_EULA Y
ENV MSSQL_PID Express

WORKDIR /usr/src/app

COPY ./Todo.Db .

USER root
RUN chmod +x /usr/src/app/script/init.sh
CMD /bin/bash /usr/src/app/script/entrypoint.sh