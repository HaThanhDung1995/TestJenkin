
pipeline {
    agent any
    stages {
        stage('DEV BRANCH'){
            when {
                branch 'DEV'
            }
            environment {
                GIT_BRANCH = 'DEV'
                GitToken = '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'
                GitUrl = "https://${env.GitToken}@github.com/HaThanhDung1995/TestJenkin"
                ENV = 'Development'
                BUILD_CONFIG = 'Release'
                DOTNET_VERSION = 'net8.0'
                SLN = '.\\src\\DemoCICD.API\\DemoCICD.API.csproj'
                WEB_SITE = 'democicd.dev.com'
                APP_POOL = 'democicd.dev.com'
                PUBLISH_PATH = '.\\src\\DemoCICD.API\\bin\\%BUILD_CONFIG%\\%DOTNET_VERSION%\\publish'
                WWW_ROOT = 'C:\\www\\DemoCICD\\BE\\DEV'
                
                SlnUnitTest = '.\\DemoCICD.sln'
                TestResultFileName = 'UnitTestRestult.trx'
                TrxFilePath = '.\\test\\DemoCICD.Architecture.Tests\\TestResults'
                MainDirectory = 'C:\\WWW\\DemoCICD\\TestResults\\'
	        }
            steps {
                    git branch: "${env.GIT_BRANCH}", url: "${env.GitUrl}"
                    echo 'git branch'
                    bat "dotnet restore ${env.SLN}"
                    echo 'dotnet restore'
                    bat "dotnet clean ${env.SLN}"
                    echo 'dotnet clean'
                    bat "dotnet build ${env.SLN} --configuration ${env.BUILD_CONFIG}"
                    echo 'dotnet build'
                    bat "dotnet test ${env.SlnUnitTest} -l:trx;LogFileName=${env.TestResultFileName}"
                    
                    bat "if not exist ${env.MainDirectory} mkdir ${env.MainDirectory}"
                    bat "copy ${env.TrxFilePath}\\${env.TestResultFileName} ${env.MainDirectory}"
                    echo 'dotnet test'
                    bat "dotnet publish ${env.SLN} /p:Configuration=${env.BUILD_CONFIG} /p:EnvironmentName=${env.ENV}"
                    echo 'dotnet publish'
                    bat "%windir%\\system32\\inetsrv\\appcmd stop sites ${env.WEB_SITE}"
                    bat "%windir%\\system32\\inetsrv\\appcmd stop apppool /apppool.name:${env.APP_POOL}"
                    bat "echo waiting until service stopped"
                    bat "ping google.com /n 5"
                    bat "xcopy ${env.PUBLISH_PATH} ${env.WWW_ROOT} /e /y /i /r"
                    bat "%windir%\\system32\\inetsrv\\appcmd start apppool /apppool.name:${env.APP_POOL}"
                    bat "%windir%\\system32\\inetsrv\\appcmd start sites ${env.WEB_SITE}"
                }
            
            
        }
        stage('PRODUCTION BRANCH'){
            when {
                branch 'main'
            }
            steps {
                echo 'main branch'
            }
        }
        
    }
}
