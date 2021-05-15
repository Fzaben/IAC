pipeline {
  agent any
  stages {
    stage('Restore packages') {
      steps {
        echo 'Hello World' && \
        dotnet restore apps/aspnet-core/DevOps.sln
      }
    }
  }
}