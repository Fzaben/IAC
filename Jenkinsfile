pipeline {
  agent any
  stages {
    stage('test') {
      steps {
        ls -la
      }
    }
    stage('Restore packages') {
      steps {
        dotnet restore apps/aspnet-core/DevOps.sln 
      }
    }
  }
}