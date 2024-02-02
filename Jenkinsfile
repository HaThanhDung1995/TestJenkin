
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
                    echo "BRANCH_NAME = ${env.BRANCH_NAME}"
                    echo "CHANGE_TARGET = ${env.CHANGE_TARGET}"
                    bat "dotnet restore ${env.SLN}"
                    echo 'dotnet restore'
                    bat "dotnet clean ${env.SLN}"
                    echo 'dotnet clean'
                    bat "dotnet build ${env.SLN} --configuration ${env.BUILD_CONFIG}"
                    echo 'dotnet build'
                    bat "dotnet test ${env.SlnUnitTest} -l:trx;LogFileName=${env.TestResultFileName}"
                    
                    bat "if not exist ${env.MainDirectory} mkdir ${env.MainDirectory}"
                    bat "copy ${env.TrxFilePath}\\${env.TestResultFileName} ${env.MainDirectory}"
                    echo 'dotnet test2'
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
                branch 'PRO'
            }
            environment {
                GIT_BRANCH = 'PRO'
                GitToken = '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'
                GitUrl = "https://${env.GitToken}@github.com/HaThanhDung1995/TestJenkin"
                ENV = 'Production'
                BUILD_CONFIG = 'Release'
                DOTNET_VERSION = 'net8.0'
                SLN = '.\\src\\DemoCICD.API\\DemoCICD.API.csproj'
                WEB_SITE = 'democicd.prod.com'
                APP_POOL = 'democicd.prod.com'
                PUBLISH_PATH = '.\\src\\DemoCICD.API\\bin\\%BUILD_CONFIG%\\%DOTNET_VERSION%\\publish'
                WWW_ROOT = 'C:\\www\\DemoCICD\\BE\\PROD'
                
                BACKUP = 'C:\\www\\DemoCICD\\BE\\PROD_BACKUP\\PROD_%date:~-4%%date:~4,2%%date:~7,2%_%time:~0,2%%time:~3,2%%time:~6,2%'
	        }
            steps {
                echo "BRANCH_NAME = ${env.BRANCH_NAME}"
                echo "CHANGE_TARGET = ${env.CHANGE_TARGET}"
                echo 'BackUp'
                bat "xcopy ${env.WWW_ROOT} ${env.BACKUP} /e /y /i /r"
                echo 'git branch'
                git branch: "${env.GIT_BRANCH}", url: "${env.GitUrl}"
                echo 'dotnet restore'
                bat "dotnet restore ${env.SLN}"
                echo 'dotnet clean'
                bat "dotnet clean ${env.SLN}"
                echo 'dotnet build'
                bat "dotnet build ${env.SLN} --configuration ${env.BUILD_CONFIG}"
                echo 'dotnet publish'
                bat "dotnet publish ${env.SLN} /p:Configuration=${env.BUILD_CONFIG} /p:EnvironmentName=${env.ENV}"
                echo 'stop IIS'
                bat "%windir%\\system32\\inetsrv\\appcmd stop sites ${env.WEB_SITE}"
				bat "%windir%\\system32\\inetsrv\\appcmd stop apppool /apppool.name:${env.APP_POOL}"
				bat "echo waiting until service stopped"
				bat "ping google.com /n 5"
                echo 'Copy to hosted website folder'
                bat "xcopy ${env.PUBLISH_PATH} ${env.WWW_ROOT} /e /y /i /r"
                echo 'start IIS'
                bat "%windir%\\system32\\inetsrv\\appcmd start apppool /apppool.name:${env.APP_POOL}"
				bat "%windir%\\system32\\inetsrv\\appcmd start sites ${env.WEB_SITE}"
            }
        }
        stage('MASTER BRANCH'){
            when {
                branch 'master'
            }
            steps {
                echo 'master'
            }
        }
        
    }
}
