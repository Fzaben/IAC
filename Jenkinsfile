pipeline {
  agent any
  stages {
    stage('Restore packages') {
      steps {
        "dotnet restore apps/aspnet-core/DevOps.sln"
      }
    }
  }
}